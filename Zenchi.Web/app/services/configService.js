(function () {
    angular
        .module('ZenchiDemo')
        .factory('configService', configService);

    configService.$inject = ['$http'];

    function configService($http) {
        return {
            zenchiApiProjectUrl: zenchiApiProjectUrl
        };


        function zenchiApiProjectUrl() {
            return 'https://zenchiwebapi.martydev.com/api/projects';
        }
    }

})();