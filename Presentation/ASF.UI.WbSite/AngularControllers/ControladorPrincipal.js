require('./ControladorCategoria');
require('./ControladorPagoTarjeta');
require('./ControladorCarrito');
require('./../Scripts/ngStorage.min');


var app = angular.module("AngularModuloPrincipal", [require('angular-material'),
require('angular-credit-cards'),
require('angular-ui-grid'),
require('angular-translate'),
    'AngularModuloCategoria',
    'AngularModuloTarjetaCredito',
    'AngularModuloCarrito',
    'ngStorage',
require('angular-translate')]);


app.factory('customLoader', function ($http, $q) {
    // return loaderFn
    return function (options) {
        var deferred = $q.defer();

        var requestParams = {};
        requestParams[options.queryParameter || 'id'] = options.key;

        return $http(angular.extend({
            url: '../../LocaleStringResource/ListaLocaleStringResource',
            params: requestParams,
            method: 'GET'
        }, options.$http))
            .then(function (result) {
                return result.data;
            }, function () {
                return $q.reject(options.key);
            });
    };

});

app.config(function ($locationProvider, $translateProvider) {
    //$locationProvider.html5Mode(true);

    console.log($translateProvider);
    $translateProvider.useLoaderCache(true);
    $translateProvider.useLoader('customLoader');
    $translateProvider.preferredLanguage('es');

});

app.run(function ($rootScope, $translate, $localStorage) {

    console.log($localStorage.Lenguaje);
    if ($localStorage.Lenguaje !== '') {

        $translate.use($localStorage.Lenguaje);
    }

});

app.controller("ControladorPrincipal", function ($scope, Dialogs, $translate, $http, $rootScope, $localStorage) {



    var arr = [1, 2, 3, 4, 5];
    var doubled = arr.select(function (t) { return t * 2 });  // [2, 4, 6, 8, 10]


    
    $scope.SetLenguaje = function (value) {
        $translate.use(value);
        $localStorage.Lenguaje = value;
        //console.log(value);

    }


    $scope.Lenguajes = [];

    $scope.ListaLanguajes = function () {


        $http({
            method: "GET",
            url: "../../Languaje/ListaLenguajes"
        }).then(function mySuccess(response) {
            console.log(response.data);

            $scope.Lenguajes = response.data;



        }, function myError(response) {

        });


    }

    $scope.ListaLanguajes();


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

