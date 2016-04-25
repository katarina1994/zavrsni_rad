var web = angular.module('web', ['ngRoute', 'ngCookies', 'LocalStorageModule', 'ui.bootstrap']);


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
    }).otherwise({
        redirectTo: '/index'
    });
}]);