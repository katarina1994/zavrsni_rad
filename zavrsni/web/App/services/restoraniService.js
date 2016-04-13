web.factory('restoraniService', ['$http', function ($http) {

    var restoraniService = {};

    restoraniService.getRestorani = function () {
        return $http.get('api/Restorani');
    }

    restoraniService.getRestoraniByDistance = function (id) {
        return $http.get('api/Restorani/GetRestoraniByDistance/'+id);
    }

  
    return restoraniService;
}]);
