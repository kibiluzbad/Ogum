# @reference ../lib/backbone.js
# @reference models/task.coffee
# @reference collections/tasks.coffee
# @reference views/newTaskView.coffee
# @reference views/taskView.coffee
# @reference views/tasksView.coffee
# @reference views/appView.coffee

@app = window.app ? {}

jQuery ->
  appView = new app.AppView collection: app.Tasks
  app.Tasks.fetch()