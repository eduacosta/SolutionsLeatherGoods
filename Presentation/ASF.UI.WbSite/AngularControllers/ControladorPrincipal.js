require('./ControladorCategoria');
require('./ControladorPagoTarjeta');
require('./ControladorCarrito');

var app = angular.module("AngularModuloPrincipal", [require('angular-material'), require('angular-credit-cards'), require('angular-ui-grid'), require('angular-translate'), 'AngularModuloCategoria','AngularModuloTarjetaCredito','AngularModuloCarrito']);

app.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});

app.controller("ControladorPrincipal", function ($scope, Dialogs) {
    $scope.firstName = "John";
    $scope.lastName = "Doe";
    console.log("eduddd");

    var arr = [1, 2, 3, 4, 5];
    var doubled = arr.select(function (t) { return t * 2 });  // [2, 4, 6, 8, 10]

    console.log(doubled);


    $scope.Login = function (evento) {

        console.log('anda');
        //Dialogs.showAlert('Hola', "Hola", evento);

        Dialogs.showCustom(evento, ControladorLogin, '../../Views/Carrito/Login.html');
    }


    function ControladorLogin($scope) {

        $scope.Username = '';
        $scope.Password = '';


        $scope.Login = function() {

            console.log($scope.Username);
        }

    }




});
app.config(function ($mdThemingProvider) {
    $mdThemingProvider.theme('default')
        .primaryPalette('pink')
        .accentPalette('orange');
});
app.service('Dialogs',
    function ($mdDialog) {


        this.showAlert = function (titulo, contenido, evento) {

            $mdDialog.show(
                $mdDialog.alert()
                    .parent(angular.element(document.body))
                    .clickOutsideToClose(false)
                    .targetEvent(evento)
                    .title(titulo)
                    .textContent(contenido)
                    .multiple(true)
                    .ok('OK')
            );
        };


        this.showConfirm = function (titulo, contenido, evento) {
            var confirm = $mdDialog.confirm()
                .title(titulo)
                .textContent(contenido)
                .targetEvent(evento)
                .multiple(true)
                .ok('Si')
                .fullscreen(true)
                .cancel('No');

            return confirm;
        };


        this.showCustom = function (evento, controlador, html, datos) {


            $mdDialog.show({
                controller: controlador,
                templateUrl: html,
                locals: { datos: datos },
                parent: angular.element(document.body),
                targetEvent: evento,
                clickOutsideToClose: false,
                multiple: true,
                fullscreen: true // Only for -xs, -sm breakpoints.
            });


        }


    });

