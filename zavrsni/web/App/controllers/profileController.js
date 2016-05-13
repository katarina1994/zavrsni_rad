web.controller('profileController', ['$scope', 'authService', 'restoraniService', 'jela1Service', 'odabranoJeloService', 'odabranoJelo1Service', function ($scope, authService, restoraniService, jela1Service, odabranoJeloService, odabranoJelo1Service) {

    $scope.authentication = authService.authentication;
    $scope.narudzba = {};
    $scope.jela = null;
    $scope.narudzba = odabranoJelo1Service.get();
    for (i = 0; i < $scope.narudzba.length; i++) {

        restoraniService.getRestoraniByID($scope.narudzba[i][5]).then(function (result) {
            $scope.restoran = result.data;
        });

    
    }
    
    $scope.ime = $scope.authentication.ime;
    $scope.prezime = $scope.authentication.prezime;
    $scope.username = $scope.authentication.userName;
    $scope.lozinka = "";
    $scope.email="";
}]);
