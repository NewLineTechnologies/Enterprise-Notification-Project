function CQRSApiWrapper() {   
    this.promises = {};
    this.subscriptions = [];

    var notificationHub = $.connection.notificationHub;

    $.connection.hub.received(function (data) {
        console.log(data);
    });

    notificationHub.client.notify = function (message) {
        console.log(message);

        if (this.promises[message.MessageId]) {
            console.log('notification got');
            this.promises[message.MessageId].resolve({});
        }

        if (message.Command.Sender != this.currentUser) {
            this.subscriptions.forEach(function (item) {
                item(message);
            });                
        }

    }.bind(this); 
}

CQRSApiWrapper.prototype.subscribe = function (callback) {
    this.subscriptions.push(callback);
}

CQRSApiWrapper.prototype.unsubscribe = function (callback) {
    var index = this.subscriptions.indexOf(callback);

    if (index != -1) {
        this.subscriptions.splice(index, 1);
    }
}

CQRSApiWrapper.prototype.init = function () {
    var def = $.Deferred();

    $.connection.hub.start().done(function () {
        console.log('connected');
        def.resolve({})
    });

    return $.when(def);
}


CQRSApiWrapper.prototype.post = function (url, entity) {
    console.log('request sent');
    return $.post(url, entity).then(function (messageId) {
        console.log('response got');
        var def = $.Deferred();
        this.promises[messageId] = def;
        return $.when(def);
    }.bind(this));
}


window.ApiWrapper = new CQRSApiWrapper();