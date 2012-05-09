(function() {
  var Tasks, _ref,
    __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  Tasks = (function(_super) {

    __extends(Tasks, _super);

    Tasks.name = 'Tasks';

    function Tasks() {
      return Tasks.__super__.constructor.apply(this, arguments);
    }

    Tasks.prototype.model = app.Task;

    Tasks.prototype.url = '/api/tasks';

    Tasks.prototype.initialize = function(options) {
      return this.bind('destroy', this.willDestroyTask, this);
    };

    Tasks.prototype.willDestroyTask = function(task) {
      return this.registerUndo(task.toJSON());
    };

    Tasks.prototype.registerUndo = function(attributes) {
      this.undoAttributes = attributes;
      if (this.undoAttributes.id) {
        return delete this.undoAttributes.id;
      }
    };

    Tasks.prototype.resetUndo = function() {
      return this.undoAttributes = null;
    };

    Tasks.prototype.applyUndo = function() {
      if (this.undoAttributes != null) {
        this.create({
          Name: "" + this.undoAttributes.Name + " #" + this.undoAttributes.Tag
        });
      }
      return this.resetUndo();
    };

    Tasks.prototype.undoItem = function() {
      return this.undoAttributes;
    };

    Tasks.prototype.setDate = function(year, month, day) {
      var date, _ref, _ref1;
      if (month === void 0 && day === void 0) {
        date = year;
        _ref = [date.getFullYear(), date.getMonth() + 1, date.getDate()], year = _ref[0], month = _ref[1], day = _ref[2];
      }
      _ref1 = [year, month, day], this.year = _ref1[0], this.month = _ref1[1], this.day = _ref1[2];
      this.url = "/api/tasks/" + year + "/" + month + "/" + day;
      this.resetUndo();
      this.fetch();
      return this.trigger('change:date');
    };

    Tasks.prototype.currentDate = function() {
      return new XDate(this.year, this.month, this.day);
    };

    Tasks.prototype.completedTasks = function() {
      return this.filter(function(task) {
        return task.isCompleted();
      });
    };

    Tasks.prototype.incompleteTasks = function() {
      return this.reject(function(task) {
        return task.isCompleted();
      });
    };

    Tasks.prototype.getToPreviousDate = function() {
      var date;
      date = this.currentDate().addDays(-1);
      return date;
    };

    Tasks.prototype.getToNextDate = function() {
      var date;
      date = this.currentDate().addDays(1);
      return date;
    };

    Tasks.prototype.isToday = function() {
      var date, today;
      date = this.currentDate();
      today = XDate.today().toDate();
      return date.getFullYear() === today.getFullYear() && date.getMonth() === today.getMonth() && date.getDate() === today.getDate();
    };

    return Tasks;

  })(Backbone.Collection);

  this.app = (_ref = window.app) != null ? _ref : {};

  this.app.Tasks = new Tasks;

}).call(this);
