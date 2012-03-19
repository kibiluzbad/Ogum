jQuery -> 
  @app = window.app ? {}

  class DateTitleView extends Backbone.View
    template: $("#dateTitleTemplate")
    render: ->
      ($ @el).html @template.tmpl({date:@collection.currentDate().toLocaleDateString()})
      @
  @app.DateTitleView = DateTitleView