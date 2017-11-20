var Carrito = angular.module("AngularModuloCarrito", []);


//import '../node_modules/angular-ui-grid/ui-grid.min.css';

Carrito.controller("ControladorCarrito",
    function ($scope, $http, $mdDialog, Dialogs, $timeout, $log) {


        var vm = this;


        vm.AnadirCarrito = function (productid, precio, event) {
            var datospost = { ProductId: productid, Precio: precio };

            $http({
                method: "POST",
                url: "/CartItem/Carrito",
                data: datospost
            }).then(function mySuccess(response) {
                console.log(response);
                $timeout(Dialogs.showAlert('Información', response.data, event), 500);
            },
                function myError(response) {
                    $timeout(Dialogs.showAlert('Error', response.data, event), 500);
                });
        }


        vm.EliminarProductoCarrito = function (productid, event) {

            $mdDialog.show(Dialogs.showConfirm("Eliminar producto", "Desea el producto del carrito?", event)).then(
                function () {
                    console.log(productid);
                    $http({
                        method: "GET",
                        url: "/CartItem/EliminarPro?id=" + productid

                    }).then(function mySuccess(response) {
                        var url = "/CartItem/CartItemXCookie";
                        window.location.href = url;
                    },
                        function myError(response) {
                            $timeout(Dialogs.showAlert('Error', response.data, event), 500);
                        });

                }, function () {

                });

        }



       
        vm.simulateQuery = false;
        vm.isDisabled = false;

        // list of states to be displayed
        vm.states = loadAll();
        vm.querySearch = querySearch;
        vm.selectedItemChange = selectedItemChange;
        vm.searchTextChange = searchTextChange;
        vm.newState = newState;

        function newState(state) {
            alert("This functionality is yet to be implemented!");
        }

        function querySearch(query) {

            console.log(query);
            var results = query ? vm.states.filter(createFilterFor(query)) :
                    vm.states, deferred;

            if (vm.simulateQuery) {
                deferred = $q.defer();

                $timeout(function () {
                        deferred.resolve(results);
                    },
                    Math.random() * 1000, false);
                return deferred.promise;
            } else {
                return results;
            }
        }

        function searchTextChange(text) {
            $log.info('Text changed to ' + text);
        }

        function selectedItemChange(item) {
            $log.info('Item changed to ' + JSON.stringify(item));
        }

        //build list of states as map of key-value pairs
        function loadAll() {
            var repos = [
                {
                    'name': 'AngularJS',
                    'url': 'https://github.com/angular/angular.js',
                    'watchers': '3,623',
                    'forks': '16,175',
                },
                {
                    'name': 'Angular',
                    'url': 'https://github.com/angular/angular',
                    'watchers': '469',
                    'forks': '760',
                },
                {
                    'name': 'AngularJS Material',
                    'url': 'https://github.com/angular/material',
                    'watchers': '727',
                    'forks': '1,241',
                },
                {
                    'name': 'Angular Material',
                    'url': 'https://github.com/angular/material2',
                    'watchers': '727',
                    'forks': '1,241',
                },
                {
                    'name': 'Bower Material',
                    'url': 'https://github.com/angular/bower-material',
                    'watchers': '42',
                    'forks': '84',
                },
                {
                    'name': 'Material Start',
                    'url': 'https://github.com/angular/material-start',
                    'watchers': '81',
                    'forks': '303',
                }
            ];
            return repos.map(function (repo) {
                repo.value = repo.name.toLowerCase();
                return repo;
            });
        }

        //filter function for search query
        function createFilterFor(query) {
            var lowercaseQuery = angular.lowercase(query);
            return function filterFn(state) {
                return (state.value.indexOf(lowercaseQuery) === 0);
            };
        }




    });