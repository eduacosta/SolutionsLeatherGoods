'use strict';
var angulars = require('angular');
var angularmodulo = angulars.module('AngularModuloPrincipal', []);
angularmodulo.controller('ctrControladorPrincipal','$scope','$http',
    function($scope, $http) {

        console.log('Edu');

    });

