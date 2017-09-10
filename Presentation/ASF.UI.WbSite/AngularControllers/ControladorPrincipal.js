require('./ControladorCategory');

var app = angular.module("AngularModuloPrincipal", [require('angular-material'), require('angular-ui-grid'), 'AngularModuloCategory']);

app.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});  

app.controller("ctrControladorPrincipal", function ($scope) {
    $scope.firstName = "John";
    $scope.lastName = "Doe";
    console.log("eduddd");
});

