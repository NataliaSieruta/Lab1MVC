from django.urls import path
<<<<<<< HEAD
from . import views

app_name = "polls"

urlpatterns = [
    path("", views.IndexView.as_view(), name="index"),
    path("<int:pk>/", views.DetailView.as_view(), name="detail"),
    path("<int:pk>/results/", views.ResultsView.as_view(), name="results"),
=======

from . import views

urlpatterns = [
    path("", views.index, name="index"),
    path("<int:question_id>/", views.detail, name="detail"),
    path("<int:question_id>/results/", views.results, name="results"),
>>>>>>> 7b1b60e9d984d2bf747492ba2561eaaecc70ecc4
    path("<int:question_id>/vote/", views.vote, name="vote"),
]