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
      @collection.goToPreviousDate()
    goToToday: (event) ->
      date = new Date
      @collection.setDate date
    goToNextDate: (event) ->
      @collection.goToNextDate()
  @app.MenuView = MenuView