web.controller('profileController', ['$scope', 'authService', 'restoraniService', 'jela1Service', 'odabranoJeloService', 'odabranoJelo1Service', function ($scope, authService, restoraniService, jela1Service, odabranoJeloService, odabranoJelo1Service) {

    $scope.restoran = [];
    $scope.authentication = authService.authentication;
    $scope.narudzbe = [];
    $scope.jela = null;
    $scope.ukupna_cijena = 0;
    $scope.odabrana = null;
    $scope.narudzbe = odabranoJelo1Service.get();
 
    
    for (i = 0; i < $scope.narudzbe.length; i++) {
        
        for (j = 0; j < $scope.narudzbe[i].length; j++) {
            $scope.ukupna_cijena += $scope.narudzbe[i][j][3]
            restoraniService.getRestoraniByID($scope.narudzbe[i][j][5]).then(function (result) {
                $scope.restoran.push(result.data);                
               
            });
        }
       
    }
    

    $scope.ime = $scope.authentication.ime;
    $scope.prezime = $scope.authentication.prezime;
    $scope.username = $scope.authentication.userName;
    $scope.email = $scope.authentication.email;
}]);
