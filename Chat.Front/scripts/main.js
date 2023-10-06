function ready() {
    console.log("js is active");
}

document.addEventListener("DOMContentLoaded", ready);

const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://wjwddj3d-7047.euw.devtunnels.ms/hub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");

        await SendMessage("hello");

    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});


async function SendMessage(messageText){
    try {
        let user = new User(1, "qwe");
        let message = new Message(1, messageText, 1,2, true);

        console.log("send message to user: ");
        console.log(user);
        console.log("send message: ");
        console.log(message);
        await connection.invoke("SendMessage", user, message);
    } catch (err) {
        console.error(err);
    }
}

connection.on("ReceiveMessage", (user, message) => {
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


