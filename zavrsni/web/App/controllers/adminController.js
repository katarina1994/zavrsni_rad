web.controller('adminController', ['$scope', '$location', 'authService', '$cookieStore', 'adminService', 'restoraniService', function ($scope, $location, authService, $cookieStore, adminService, restoraniService) {

    $scope.restorani = [];
    $scope.ovlasti = [];
    $scope.ovlasti[1] = "administrator";
    $scope.ovlasti[2] = "korisnik";
    $scope.ovlasti[3] = "voditelj restorana";



    adminService.getUsers().then(function (result) {
        $scope.korisnici = result.data;

        for (i = 0; i < $scope.korisnici.length; i++) {
            
            restoraniService.getRestoraniByID($scope.korisnici[i].restID).then(function (result) {
                if (result.data[0]) {
                    $scope.restorani[result.data[0].id] = result.data;
                }
            });
        }

    });


    $scope.izbrisano = [];
    $scope.izbrisi = function (korisnik) {
        
        adminService.deleteKorisnik(korisnik.id).then(function (result) {
            $scope.izbrisano[korisnik.id] = 1;
            $route.reload();
            
        });
    }
}]);