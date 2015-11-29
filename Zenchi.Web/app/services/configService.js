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
            return 'http://localhost:2454/api/projects';
        }
    }

})();