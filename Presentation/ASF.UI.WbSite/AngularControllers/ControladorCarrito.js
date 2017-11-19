var Carrito = angular.module("AngularModuloCarrito", []);


//import '../node_modules/angular-ui-grid/ui-grid.min.css';

Carrito.controller("ControladorCarrito",
    function ($scope, $http, $mdDialog, Dialogs, $timeout) {


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


    });