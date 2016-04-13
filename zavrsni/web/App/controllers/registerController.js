web.controller('registerController', ['$scope', '$location', '$timeout', 'authService',function ($scope, $location, $timeout, authService) {


    $scope.savedSuccessfully = false;
    $scope.message = "";
    $scope.loginData = {
        userName: "",
        password: ""
    }

    $scope.registration = {
        ime: "",
        prezime: "",
        userName: "",
        email: "",
        password: "",
        confirmPassword: ""
    }

 
 
    $scope.register = function () {


            authService.saveRegistration($scope.registration).then(function (response) {

                $scope.loginData.userName = $scope.registration.userName;
                $scope.loginData.password = $scope.registration.password;
                authService.login($scope.loginData).then(function (response) {
                    //$location.path('#/' + response.NEXTPAGE);
                },
                    function (err) {
                        $scope.message = err.error_description;
                    }
                );

                $scope.savedSuccessfully = true;
                $scope.message = "Vš je profil uspješno registriran.Bit ćete preusmjereni na " + response.data + "stranicu za 2 sekunde.";
                startTimer(response.data);

            }, function (response) {
                var errors = [];
                for (var key in response.data.modelState) {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
                $scope.message = "Registracija nije uspjela: " + errors.join(' ');
            }
            );
      
    };

    var startTimer = function (path) {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/' + path);
        }, 2000);
    }
}]);