function TasksApi() {

    
}

TasksApi.prototype.takeTask = function (sender, taskUuid) {
    return window.ApiWrapper.post("/api/tasks/takeTask", {
        sender: sender,
        taskUuid: taskUuid
    })
}


TasksApi.prototype.finishTask = function (sender, taskUuid) {
    return window.ApiWrapper.post("/api/tasks/finishTask", {
        sender: sender,
        taskUuid: taskUuid
    })
}

TasksApi.prototype.leaveCommentOnTask = function (sender, taskUuid, comment) {
    return window.ApiWrapper.post("/api/tasks/leaveCommentOnTask", {
        sender: sender,
        taskUuid: taskUuid,
        comment: comment
    })
}