function UserApi() {

    
}

UserApi.prototype.login = function (email, password) {
    return window.ApiWrapper.post("/api/auth/login", {
        email: email,
        password: password
    })
}


UserApi.prototype.logout = function (email) {
    return window.ApiWrapper.post("/api/auth/logout", {
        email: email      
    })
}

UserApi.prototype.getRecentActivities = function (email) {
    return $.get("/api/users/getRecentActivities?userName=" + email);
}

UserApi.prototype.sendMessage = function (sender, recipient, text) {

    return window.ApiWrapper.post("/api/messages/sendMessage", {
        sender: sender,
        recipient: recipient,
        text: text
    })
};

UserApi.prototype.getUnreadMessages = function (email) {
    return $.get("/api/users/getUnreadMessages?userName=" + email);
}