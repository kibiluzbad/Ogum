(function() {
  var __hasProp = Object.prototype.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor; child.__super__ = parent.prototype; return child; };

  jQuery(function() {
    var NewTaskView, _ref;
    this.app = (_ref = window.app) != null ? _ref : {};
    NewTaskView = (function(_super) {

      __extends(NewTaskView, _super);

      function NewTaskView() {
        NewTaskView.__super__.constructor.apply(this, arguments);
      }

      NewTaskView.prototype.tagName = 'newTaskForm';

      NewTaskView.prototype.template = $("#newTaskViewTemplate");

      NewTaskView.prototype.initialize = function(options) {};

      NewTaskView.prototype.events = {
        'keypress #task-text': 'saveOnEnter',
        'focusout #task-text': 'hideWarning'
      };

      NewTaskView.prototype.render = function() {
        if (this.collection.isToday()) {
          ($(this.el)).html(this.template.tmpl());
          this.delegateEvents();
        } else {
          $(this.el).empty();
        }
        return this;
      };

      NewTaskView.prototype.saveOnEnter = function(event) {
        var errorCallback, newAttirbutes;
        if (event.keyCode === 13) {
          event.preventDefault();
          newAttirbutes = {
            Name: $('#task-text').val()
          };
          errorCallback = {
            error: this.flashWarning
          };
          if (this.collection.create(newAttirbutes, errorCallback)) {
            this.hideWarning;
            return this.focus();
          }
        }
      };

      NewTaskView.prototype.focus = function() {
        return $('#task-text').val('').focus();
      };

      NewTaskView.prototype.hideWarning = function() {
        return $('#warning').hide();
      };

      NewTaskView.prototype.flashWarning = function(model, error) {
        console.log(error);
        $('#warning').fadeOut(100);
        return $('#warning').fadeIn(400);
      };

      return NewTaskView;

    })(Backbone.View);
    return this.app.NewTaskView = NewTaskView;
  });

}).call(this);
