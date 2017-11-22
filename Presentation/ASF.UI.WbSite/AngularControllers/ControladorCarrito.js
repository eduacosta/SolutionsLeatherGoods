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
        vm.include = '';
        // list of states to be displayed
        vm.prodcutos = [];
        vm.querySearch = querySearch;
        vm.selectedItemChange = selectedItemChange;
        vm.searchTextChange = searchTextChange;
        vm.newState = newState;

        function newState(state) {
            alert("This functionality is yet to be implemented!");
        }

        function querySearch(query) {


            //console.log(query);
            var results = query ? vm.prodcutos.filter(createFilterFor(query)) :
                vm.prodcutos, deferred;

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
            //$log.info('Text changed to ' + text);
            vm.include = '';

            $http({
                method: "GET",
                url: "/Product/BuscarProductoPorNombre?id=" + text

            }).then(function mySuccess(response) {
                vm.prodcutos = response.data;

                vm.prodcutos.map(function (repo) {
                    repo.value = repo.Title.toLowerCase();
                    return repo;
                });

            },
                function myError(response) {
                    $timeout(Dialogs.showAlert('Error', response.data), 500);
                });




        }

        function selectedItemChange(item) {

            console.log(item);

            if (item !== undefined) {
                vm.include = "Product/ProductosXBuscador/" + item.Title;

            }
            //$http({
            //    method: "GET",
            //    dataType : "html",
            //    url: "/Product/ProductosXBuscador?id=" + item.Title

            //}).then(function mySuccess(response) {
                   

            //    },
            //    function myError(response) {
                   
            //    });

            //$log.info('Item changed to ' + JSON.stringify(item));
        }

        

        //filter function for search query
        function createFilterFor(query) {
            var lowercaseQuery = angular.lowercase(query);
            return function filterFn(prodcutos) {
                return (prodcutos.value.indexOf(lowercaseQuery) === 0);
            };
        }




    });
