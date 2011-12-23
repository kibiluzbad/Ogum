jQuery -> 
  @app = window.app ? {}

  class UndoView extends Backbone.View
    id: 'undo-template'
    template: $('#undoTemplate')
    tagName: 'li'
    className: 'task'
    events:
      "click .undo-button":"applyUndo"
    initialize: (options) ->    
      
    render: ->
      html = @template.tmpl @collection.undoItem()
      ($ @el).html html
      @
    applyUndo: ->
      @collection.applyUndo()

  @app.UndoView = UndoView