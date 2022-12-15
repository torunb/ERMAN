const WebSocket = require("ws");

async function main() {
    const ws = new WebSocket('wss://localhost:7073/ws', {
        perMessageDeflate: false,
        rejectUnauthorized: false
    });

    ws.on('open', function open() {
        ws.send("asdasa123");
      });
      
    ws.on('message', function message(data) {
        console.log('received: %s', data);
    });

    ws.on('close', function close(data) {
        console.log("closed");
    });

}

main();