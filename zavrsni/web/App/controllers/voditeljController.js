web.controller('voditeljController', ['$scope', '$location', '$route', 'tipJelaService', 'odabranoJeloService', 'authService', 'jela1Service', 'restoraniService', function ($scope, $location, $route, tipJelaService, odabranoJeloService, authService, jela1Service, restoraniService) {
    
    $scope.tip = [];
    $scope.uklonjeno_jelo = [];
    $scope.authentication = authService.authentication;
    $scope.id_restorana = $scope.authentication.restID;
    $scope.restoran = null;
    $scope.data = null;
    $scope.odabran_id = null;
    $scope.narudzba = null;
    $scope.jelo_zapamti = [];
    var brojac = [];

    restoraniService.getRestoraniByID($scope.id_restorana).then(function (result) {
        $scope.restoran = result.data;
    });

    jela1Service.getJelaByID($scope.id_restorana).then(function (result) {
        $scope.jela = result.data;
        
        for (i = 0; i < $scope.jela.length; i++) {
            tipJelaService.getTipJelaByID($scope.jela[i].tipJelaID).then(function (result) {
                $scope.tip[result.data[0].id] = result.data[0].naziv_tipa;
              
            });
        }
    
        angular.forEach($scope.jela, function (value, key) {

            if (brojac[value.tipJelaID] != 1) {
                $scope.jelo_zapamti.push(value.tipJelaID);
                brojac[value.tipJelaID] = 1;
            }
          
        });


    });

    

    $scope.izbrisi_jelo = function (index, id) {
        jela1Service.deleteJelo(id).then(function (result) {
            $scope.uklonjeno_jelo[id] = 1;
            $scope.jela.splice(index, 1);

        });
    }

    $scope.data = {
        id: null,
        naziv: "",
        cijena: null,
        detalji: "",
        tipid: null,
        restid: null

    };
    
    $scope.dodaj_jelo = function (naziv, cijena, detalji, tipid, restid) {
       
        jela1Service.insertJelo(naziv, cijena, detalji, tipid, restid).then(function (result) {
            $route.reload();

        });
    }


    

}]);
