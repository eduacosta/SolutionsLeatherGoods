require('./ControladorCategoria');

var app = angular.module("AngularModuloPrincipal", [require('angular-material'), require('angular-ui-grid'), require('angular-translate'), 'AngularModuloCategoria']);

app.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});  

app.controller("ControladorPrincipal", function ($scope) {
    $scope.firstName = "John";
    $scope.lastName = "Doe";
    console.log("eduddd");
});

