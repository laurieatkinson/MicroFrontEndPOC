(function () {
    // Broadcast global event
    document.getElementById('sendMessageButton').onclick = () => {
        let message = document.querySelector('#webapp4 #message').value;
        microFrontEndDemo.refreshEvent.extraInfo = message ? message : "Empty message";
        document.dispatchEvent(microFrontEndDemo.refreshEvent);
    };
})();