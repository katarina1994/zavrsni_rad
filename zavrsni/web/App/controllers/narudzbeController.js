web.controller('narudzbeController', ['$scope', 'restoraniService', 'authService', 'jela1Service', 'odabranoJeloService', 'odabranoJelo1Service', function ($scope, restoraniService, authService, jela1Service, odabranoJeloService, odabranoJelo1Service) {

    $scope.authentication = authService.authentication;
    $scope.narudzba = [];
    $scope.jela = null;
    $scope.id = $scope.authentication.restID;
    
    odabranoJeloService.getOdabranaJela().then(function (result) {
        
        $scope.pomocna1 = result.data;
        console.log($scope.pomocna1);
        for (m = 0; m < $scope.pomocna1.length; m++) {
            if ($scope.id == $scope.pomocna1[m].restoranID) {
                $scope.narudzba.push($scope.pomocna1[m])
                //console.log($scope.pomocna1[m].restoranID);
            }
            
        }
        
     
        for (i = 0; i < $scope.narudzba.length; i++) {       
            restoraniService.getRestoraniByID($scope.narudzba[i].restoranID).then(function (result) {
                $scope.restoran = result.data;
            });
           
            $scope.posalji_mail = function (id) {
                //odabranoJeloService.getOdabranaJelaID(id).then(function (result) {
                 
                    //console.log(result.data[0].mail);
                    odabranoJeloService.potvrdi(id);
                //});
            }

            jela1Service.getJelaByID($scope.narudzba[i].jeloID).then(function (result) {
                $scope.pomocna = result.data;
                for (k = 0; k < $scope.pomocna.length; k++) {
                    if ($scope.id == $scope.pomocna[k].restoranID) {
                        $scope.jelo = $scope.pomocna
                     
                    }
                }
            });
        }
    });


    
}]);