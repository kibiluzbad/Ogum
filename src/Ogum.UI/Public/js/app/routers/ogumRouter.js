(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  jQuery(function() {
    var OgumRouter, _ref;
    this.app = (_ref = window.app) != null ? _ref : {};
    OgumRouter = (function(_super) {

      __extends(OgumRouter, _super);

      OgumRouter.name = 'OgumRouter';

      function OgumRouter() {
        return OgumRouter.__super__.constructor.apply(this, arguments);
      }

      OgumRouter.prototype.routes = {
        '': 'redirectToToday',
        'tasks/:year/:month/:day': 'show'
      };

      OgumRouter.prototype.initialize = function() {
        return this.view = new app.AppView({
          collection: app.Tasks
        });
      };

      OgumRouter.prototype.redirectToToday = function() {
        var day, month, today, year, _ref1;
        today = XDate.today();
        _ref1 = [today.getDate(), today.getMonth(), today.getFullYear()], day = _ref1[0], month = _ref1[1], year = _ref1[2];
        return Backbone.history.navigate("tasks/" + year + "/" + month + "/" + day, true);
      };

      OgumRouter.prototype.show = function(year, month, day) {
        return app.Tasks.setDate(year, month, day);
      };

      return OgumRouter;

    })(Backbone.Router);
    return this.app.OgumRouter = OgumRouter;
  });

}).call(this);
