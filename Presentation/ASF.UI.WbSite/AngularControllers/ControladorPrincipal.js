require('./ControladorCategoria');
require('./ControladorPagoTarjeta');
require('./ControladorCarrito');

var app = angular.module("AngularModuloPrincipal", [require('angular-material'),
require('angular-credit-cards'),
require('angular-ui-grid'),
require('angular-translate'),
    'AngularModuloCategoria',
    'AngularModuloTarjetaCredito',
    'AngularModuloCarrito',
require('angular-translate')]);


app.factory('customLoader', function ($http, $q) {
    // return loaderFn
    return function (options) {
        var deferred = $q.defer();
        // do something with $http, $q and key to load localization files

        //var _lenguajes = [];

        //$http({
        //    method: "GET",
        //    url: "Idiomas/ListaIdiomas"
        //}).then(function mySuccess(response) {
        //    console.log(response.data);
        //    _lenguajes = response.data;


        //}, function myError(response) {

        //});

        //var data = {
        //    'TEXT': 'Fooooo'
        //};

        //// resolve with translation data
        //return deferred.resolve(data);
        // or reject with language key
        //return deferred.reject(options.key);

        //if (!options || !options.url) {
        //    throw new Error('Couldn\'t use urlLoader since no url is given!');
        //}

        var requestParams = {};

        requestParams[options.queryParameter || 'id'] = options.key;

        return $http(angular.extend({
            url: 'Idiomas/ListaIdiomas',
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
    $locationProvider.html5Mode(true);




    //$http({
    //    method: "GET",
    //    url: "Idiomas/ListaIdiomas"
    //}).then(function mySuccess(response) {
    //    console.log(response.data);




    //}, function myError(response) {

    //});




    //for (var x in idiomas) {

    //    $translateProvider.translations(idiomas[x].Idioma, idiomas[x].Propiedades);

    //}

    $translateProvider.useLoaderCache(false);
    $translateProvider.useLoader('customLoader');
    $translateProvider.preferredLanguage('en');
    //$translateProvider.useLocalStorage();
});



app.controller("ControladorPrincipal", function ($scope, Dialogs, $translate) {



    var arr = [1, 2, 3, 4, 5];
    var doubled = arr.select(function (t) { return t * 2 });  // [2, 4, 6, 8, 10]



    $scope.SetLenguaje = function (value) {
        $translate.use(value);
        console.log(value);
        // Sets the active language to `en`
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

