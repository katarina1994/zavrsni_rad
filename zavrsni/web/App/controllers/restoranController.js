web.controller('restoranController', ['$scope', '$window','jelaService', 'jela1Service', 'restoraniService', 'tipJelaService', function ($scope, $window, jelaService, jela1Service, restoraniService, tipJelaService) {

    $scope.ukupna_cijena = 0;
    $scope.ukupna_kolicina = 0;
    $scope.kosarica = [];
    $scope.prazna_kosarica = 0;
    $scope.id = new Array();
    $scope.names = new Array();
    $scope.price = new Array();
    $scope.quantity = new Array();
    $scope.jela = null;
    $scope.tip = [];
    $scope.id_restorana = null;
    $scope.id_restorana = jelaService.get();
    $scope.otvoren = null;
    $scope.restoran = null;
    $scope.klik = [];
 
 
    

    restoraniService.getRestoraniByID($scope.id_restorana).then(function (result) {
        $scope.restoran = result.data;
        console.log($scope.restoran);

    });

    jela1Service.getJelaByID($scope.id_restorana).then(function (result) {
        $scope.jela = result.data;
        for (i = 0; i < $scope.jela.length; i++) {
            tipJelaService.getTipJelaByID($scope.jela[i].tipJelaID).then(function (result) {
                $scope.tip.push(result.data);              
            });
        }       
    });
  

   
  


    $scope.addItem = function (id, name, price, quantity) {
        
        $scope.klik[id] = 1;
        if ($scope.kosarica[id] == null) {
            $scope.price[id] = 0;
            $scope.quantity[id] = 0;
        }

        $scope.price[id] += price;
        $scope.quantity[id] += quantity;

        $scope.prazna_kosarica = 1;
        $scope.kosarica[id] = [name, $scope.price[id], $scope.quantity[id]];
        $scope.ukupna_cijena += price;
        $scope.ukupna_kolicina += quantity;
        
    }

    $scope.removeItem = function (id, name, price, quantity) {
        
        $scope.price[id] -= price;
        $scope.quantity[id] -= quantity;
        $scope.kosarica[id] = [name, $scope.price[id], $scope.quantity[id]];
        $scope.ukupna_cijena -= price ;
        $scope.ukupna_kolicina -= quantity;
        var zap = $scope.kosarica[id][2];
        if (zap == 0) {
            
            $scope.klik[id] = null;
            $scope.kosarica[id] = [null, null, null];
        }
        
        
    }



    restoraniService.getRestoraniByID($scope.id_restorana).then(function (result) {
        $scope.restoran = result.data;
        var today = new Date().getHours();

        if (today >= $scope.restoran[0].vrijeme_otvaranja && today <= $scope.restoran[0].vrijeme_zatvaranja) {
            $scope.otvoren = 1;
        } else {
            $scope.otvoren = 0;
        }

    });

   

}]);
