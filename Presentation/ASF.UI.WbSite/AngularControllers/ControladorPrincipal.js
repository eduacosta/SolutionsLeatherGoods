var angulars = require('angular');
//import modulo from './ControladorCategory';
var principal = angulars.module('ModuloPrincipal',[]);
principal.controller('ctrControladorPrincipal',['$scope','$http',
    function($scope, $http) {

        console.log('Edu');

    }]);


module.exports = principal;

