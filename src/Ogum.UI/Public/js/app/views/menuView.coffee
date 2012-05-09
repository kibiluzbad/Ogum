jQuery ->
  @app = window.app ? {}

  class MenuView extends Backbone.View
    tagName: 'nav'
    template: $("#menuTemplate")
    initialize: (options) ->
    
    events:
      'click .previous': 'goToPreviousDate'
      'click .today':    'goToToday'
      'click .next':     'goToNextDate'
    render: ->
      ($ @el).html @template.tmpl()
      @delegateEvents()
      @
    goToPreviousDate: (event) ->
      date = @collection.getToPreviousDate()
      Backbone.history.navigate "tasks/#{date.getFullYear()}/#{date.getMonth()}/#{date.getDate()}", true
    goToToday: (event) ->
      date = new Date
      @collection.setDate date
    goToNextDate: (event) ->
      date = @collection.getToNextDate()
      Backbone.history.navigate "tasks/#{date.getFullYear()}/#{date.getMonth()}/#{date.getDate()}", true
  @app.MenuView = MenuView