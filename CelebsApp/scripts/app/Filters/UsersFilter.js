var app = angular.module('app');

app.filter('celebsFilter', function () {
 
    return function (celebs, name) {
        if (name) {
            return celebs.filter(function (celeb) {
                ;
                return celeb.CelebName.indexOf(name) > -1
            });
        }
          return celebs;
    };
});