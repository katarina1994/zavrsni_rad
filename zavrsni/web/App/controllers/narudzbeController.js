web.controller('narudzbeController', ['$scope', 'restoraniService', 'authService', 'jela1Service', 'odabranoJeloService', 'odabranoJelo1Service', function ($scope, restoraniService, authService, jela1Service, odabranoJeloService, odabranoJelo1Service) {

    $scope.authentication = authService.authentication;
    $scope.narudzba = null;
    $scope.jela = null;
    $scope.id = $scope.authentication.restID;
    
    odabranoJeloService.getOdabranaJela().then(function (result) {
        $scope.narudzba = result.data;
        
     
        for (i = 0; i < $scope.narudzba.length; i++) {       
            restoraniService.getRestoraniByID($scope.narudzba[i].restoranID).then(function (result) {
                $scope.restoran = result.data;
            });

            jela1Service.getJelaByID($scope.narudzba[i].jeloID).then(function (result) {
                $scope.jelo = result.data;
                console.log($scope.jelo);
            });
        }
    });



}]);