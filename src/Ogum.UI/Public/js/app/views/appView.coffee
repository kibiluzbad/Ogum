# @reference tasksView.coffee
jQuery -> 
  @app = window.app ? {}

  class AppView extends Backbone.View
    el: '#wrap'
    initialize: (options) ->
      @subviews = [
        new app.TasksView collection: @collection
        new app.NewTaskView collection: @collection
        ]
      @collection.bind 'reset', @render, @
    render: ->
      $(@el).empty()
      $(@el).append subview.render().el for subview in @subviews
      @

  @app.AppView = AppView