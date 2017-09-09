
require('./ControladorCategory');

var app = angular.module("AngularModuloPrincipal", ['AngularModuloCategory']);


app.controller("ctrControladorPrincipal", function ($scope) {
    $scope.firstName = "John";
    $scope.lastName = "Doe";
    console.log("eduddd");
});

