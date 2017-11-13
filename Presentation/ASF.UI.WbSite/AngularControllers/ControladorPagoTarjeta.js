var tarjeta = angular.module("AngularModuloTarjetaCredito", []);


//import '../node_modules/angular-ui-grid/ui-grid.min.css';

tarjeta.controller("ControladorTarjetaCredito",
    function ($scope, $http, $mdDialog, Dialogs,$timeout) {


        var vm = this;

        

     


        $scope.PagarConTarjeta = function(evento, item) {


            Dialogs.showCustom(evento, DialogController, '../../Views/Shared/TarjetaCredito.html',item);

            

        }

        $scope.EliminarOrden = function(evento, item) {

           
            $mdDialog.show(Dialogs.showConfirm("Eliminar Orden", "Desea eliminar la orden generada?", evento)).then(function () {
                $http({
                    method: "GET",
                    url: "../../Order/Eliminar?id=" + item
                   
                }).then(function mySuccess(response) {

                    //Dialogs.showAlert('Compra', response.data, evento);

                   
                    window.location.pathname = "../../CartItem/CartItemXCookie";
                   
                   

                }, function myError(response) {
                    

                    Dialogs.showAlert('Error', response.data, evento);

                });
            }, function () {
                
            });;


        }




        function DialogController($scope, $mdDialog, datos) {

            $scope.ShowWait = false;

            $scope.card = {
                'holder_name': '',
                'number': '',
                'exp_month': '',
                'exp_year': '',
                'cvc': '',
                'address': '',
                'Id' : 0
            }

            $scope.cancel = function () {
                $mdDialog.cancel();
            };

            $scope.Pagar = function(event) {

               
                $scope.card.Id = datos;

                $scope.ShowWait = true;
                $http({
                    method: "POST",
                    url: "../../CartItem/PagarCompra",
                    data: $scope.card
                }).then(function mySuccess(response) {
                    console.log(response);
                    //window.location.pathname = "Category/Category/ListCategory";
                    $scope.ShowWait = false;

                  

                    Dialogs.showAlert('Compra', response.data, event);
                    $mdDialog.cancel();
                        //window.location.pathname = response.data.redirect;

                    


                }, function myError(response) {
                    $scope.ShowWait = false;

                    Dialogs.showAlert('Error', response.data, event);

                });


            }

          
        }




    });

tarjeta.filter('yesNo',
    function() {

        return function(boolean) {

            return boolean ? 'Yes' : 'No';

        }

    });