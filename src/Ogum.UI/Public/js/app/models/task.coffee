# @reference ../main.coffee
class Task extends Backbone.Model
  idAttribute: 'Id'

@app = window.app ? {}
@app.Task = Task