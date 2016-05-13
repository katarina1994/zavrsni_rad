web.controller('mainController', ['$scope', '$location', 'authService', '$cookieStore',  function ($scope, $location, authService, $cookieStore) {

    "use strict";

    $scope.authentication = authService.authentication;
    $scope.greska = 0;
    $scope.loginData = {
        userName: "",
        password: ""
    }
    

 

    $scope.message = "";
    $scope.login = function (userName, password) {
        
        authService.login($scope.loginData).then(function (response) {
            
            if (response.ovlastID == 3)
                $location.path('index');
            if (response.ovlastID == 2)
                $location.path('index');
            if (response.ovlastID == 1)
                $location.path('index');
        },
        
        function (err) {
            $scope.message = err.error_description;
            alert($scope.message);
        });
    }


    $scope.logout = function () {

        authService.logOut();
        $location.path('#/index');
        $scope.loginData = {
        userName: "",
        password: ""
        }
    }

    
}]);