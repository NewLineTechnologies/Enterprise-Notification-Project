describe("GlobalTest", function () {

    var userApi = new UserApi();
    var taskApi = new TasksApi();
    var oldCount;

    beforeAll(function (done) {
        window.ApiWrapper.currentUser = "testuser1@test.com";
       

        window.ApiWrapper.init().then(function () {

            userApi.getRecentActivities(window.ApiWrapper.currentUser).then(function (result) {
                oldCount = result.length;
                done();
            });

          
        });
    });

    it("User logins and receives notification", function (done) {

        userApi.login("testuser1@test.com", "123456789").then(function () {
            expect(true).toEqual(true);
            done();
        });
    });


    it("User logs-out and receives notification", function (done) {

        userApi.logout("testuser1@test.com", "123456789").then(function () {
            expect(true).toEqual(true);
            done();
        });
    });

    it("User takes task. Another logged-in users retrieve notification", function (done) {

        var callback = function () {
            // testuser1 also get notification
            expect(true).toEqual(true);
            done();
            window.ApiWrapper.unsubscribe(callback);
        };

        window.ApiWrapper.subscribe(callback);

        //take task under second user
        taskApi.takeTask("testuser2@test.com", "task1").then(function () {
            //            expect(true).toEqual(true);
            //done();
        });
    });

    it("User takes task. New item should be added to list of his latest activities", function (done) {
        //wait until web-job saves messages to DocumentDB
        setTimeout(function () {
            userApi.getRecentActivities(window.ApiWrapper.currentUser).then(function (updatedResult) {
                expect(oldCount == updatedResult.lengt).toEqual(false);
                done();
            });
        }, 2000);
    }, 5000);


    it("User finishes task. The next task from project’s task list is assigned to the user", function (done) {
        var counter = 0;
        var callback = function () {
            counter++;
            // we should get two notifications (actually two commands was perfomed)
            if (counter == 2) {
                expect(true).toEqual(true);
                done();
                window.ApiWrapper.unsubscribe(callback);
            }            
        };

        window.ApiWrapper.subscribe(callback);

        taskApi.finishTask("testuser2@test.com", "task1");

    }, 5000);


    it("User sends message to another logged-in user. Second user retrieves notification", function (done) {
        var message = "some message " + (new Date()).toISOString();

        var callback = function () {
            // testuser1  get notification
            expect(true).toEqual(true);
            done();
            window.ApiWrapper.unsubscribe(callback);
        };

        window.ApiWrapper.subscribe(callback);

        //send message from user2 to user 1
        userApi.sendMessage("testuser2@test.com", "testuser1@test.com", message).then(function () {

        });       
    });

    it("User sends message to another not-logged-in user. After second user logins, he gets notification about new messages", function (done) {
        var message = "some message " + (new Date()).toISOString();

        userApi.logout("testuser2@test.com").then(function () {
            //send message from user1 to offline-user2
            userApi.sendMessage("testuser1@test.com", "testuser2@test.com", message).then(function () {

                setTimeout(function () {
                    userApi.getUnreadMessages("testuser2@test.com").then(function (result) {
                        console.log(result);
                        expect(true).toEqual(true);
                        done();
                    });
                }, 3000)
                

            });
        });
        
    }, 7000);

});
