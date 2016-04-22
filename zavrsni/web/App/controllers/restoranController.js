web.controller('restoranController', ['$scope','jelaService','jela1Service', 'restoraniService', function ($scope, jelaService, jela1Service, restoraniService) {

    $scope.jela = null;
    $scope.id_restorana = null;
    $scope.id_restorana = jelaService.get();
    console.log($scope.id_restorana);
    restoraniService.getRestoraniByDistance($scope.id_restorana).then(function (result) {
        $scope.restoran = result.data;

    });

    jela1Service.getJelaByID($scope.id_restorana).then(function (result) {
        $scope.jela = result.data;
        console.log($scope.jela);
    });

}]);
