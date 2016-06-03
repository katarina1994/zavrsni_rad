var web = angular.module('web', ['ngRoute', 'ngCookies', 'LocalStorageModule', 'ui.bootstrap', 'ngDialog']);


angular.module('web').directive('ngReallyClick', ['$modal', function ($modal) {

    


    var PomController = function ($scope, $location, $modalInstance, authService) {
        $scope.okej = function () {
            $modalInstance.close()
        };

        "use strict";

        $scope.authentication = authService.authentication;
        $scope.greska = 0;
        $scope.loginData = {
            userName: "",
            password: ""
        }

        $scope.message = "";
        $scope.login = function (userName, password) {

            authService.login($scope.loginData).then(function (response) {
          
                if (response.ovlastID == 3)
                    $location.path('index');
                if (response.ovlastID == 2)
                    $location.path('index');
                if (response.ovlastID == 1)
                    $location.path('index');
            },

            function (err) {
                $scope.message = err.error_description;
                alert($scope.message);
            });

            $scope.okej();
        }


        $scope.logout = function () {

            authService.logOut();
            $location.path('#/index');
            $scope.loginData = {
                userName: "",
                password: ""
            }
        }

        
    };
    return {
        restrict: 'A',
        scope: {
            ngReallyClick: "&"
        },
        link: function (scope, element) {
            element.bind('click', function () {
                var modalIns = $modal.open({
                    templateUrl: 'App/templates/upozorenje.html',
                    controller: PomController
                });
                modalIns.result.then(function () {
                    scope.ngReallyClick({ mod: scope.mod });
                });
            });
        }
    }
}
]);


web.run(function ($rootScope) {
    $rootScope.$on("$routeChangeStart", function (event, next, current) {
        if (sessionStorage.restorestate == "true") {
            $rootScope.$broadcast('restorestate');
            sessionStorage.restorestate = false;
        }
    });

    window.onbeforeunload = function (event) {
        $rootScope.$broadcast('savestate');
    };
});



web.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

web.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/index', {
        controller: 'indexController',
        templateUrl: '/App/templates/index.html'
    }).when('/register', {
        controller: 'registerController',
        templateUrl: '/App/templates/register.html'
    }).when('/profile', {
        controller: 'profileController',
        templateUrl: '/App/templates/profile.html'
    }).when('/voditelj', {
        controller: 'voditeljController',
        templateUrl: '/App/templates/voditelj.html'
    }).when('/admin', {
        controller: 'adminController',
        templateUrl: '/App/templates/admin.html'
    }).when('/restoran', {
        controller: 'restoranController',
        templateUrl: '/App/templates/restoran.html'
    }).when('/narudzbe', {
        controller: 'narudzbeController',
        templateUrl: '/App/templates/narudzbe.html'
    }).otherwise({
        redirectTo: '/index'
    });
}]);