web.controller('mainController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.authentication = authService.authentication;

    $scope.loginData = {
        userName: "",
        password: ""
    }

    $scope.message = "";

    $scope.login = function (userName, password) {

        authService.login($scope.loginData).then(function (response) {
            if (response.ovlastID == 3)
                $location.path('voditelj');
            if (response.ovlastID == 2)
                $location.path('profile');
            if (response.ovlastID == 1)
                $location.path('admin');
        },
        function (err) {
            $scope.message = err.error_description;
        });
    }

    $scope.logout = function () {

        authService.logOut();
        $location.path('#/index');
    }
}]);