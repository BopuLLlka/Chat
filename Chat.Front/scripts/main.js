const ThisUserName = "Nyah";


function ready() {
    let imageButton = document.getElementById("imageButton");
    let textArea = document.getElementById("textArea");
    

    imageButton.addEventListener( "click" , async () => 
    {
        await SendMessage(textArea.value);
    });
}

document.addEventListener("DOMContentLoaded", ready);

const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://wjwddj3d-7047.euw.devtunnels.ms/hub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {

        console.log("starting...");
        await connection.start();
        console.log("SignalR Connected.");

        

    } catch (err) {
        console.log("ERROR!!!");

        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});


async function SendMessage(messageText){
    try {
        let user = new User(1, ThisUserName);
        let message = new Message(1, messageText, 1,2, true);

        await connection.invoke("SendMessage", user, message);
    } catch (err) {
        console.error(err);
    }
}



connection.on("ReceiveMessage", (user, message) => {
    const messageBubble = document.createElement("div");
    messageBubble.classList.add(user.name == ThisUserName ? "rightBubble" : "leftBubble");
    messageBubble.textContent = `${user.name}: ${message.text}`;
    document.getElementById("MessageContainer").appendChild(messageBubble);

    console.log(user);
    console.log(message);
});


const User = class {
    constructor(id, name) {
        this.id = id;
        this.name = name;
    }
  };


const Message = class {
    constructor(id, text, senderId, recipientId,isEveryone) {
        this.id = id;
        this.text = text;
        this.senderId = senderId;
        this.recipientId = recipientId;
        this.isEveryone = isEveryone;
    }
};



// Start the connection.
start();


