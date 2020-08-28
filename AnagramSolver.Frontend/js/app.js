'use strict';

(function () {
    function init() {
        var router = new Router([
            new Route('#', 'landing.html', true),            
            new Route('word', 'word.html'),            
            new Route('about', 'about.html')
        ]);
    }
    init();
}());
