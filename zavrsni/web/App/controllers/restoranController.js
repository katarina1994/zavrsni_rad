web.controller('restoranController', ['$scope','jelaService', function ($scope, jelaService) {

    $scope.id_restorana = null;
    $scope.id_restorana = jelaService.get();
   
    

}]);
