<<<<<<< HEAD
import datetime
from django.db import models
from django.utils import timezone
from django.contrib import admin


=======
from django.db import models

# Create your models here.
>>>>>>> 7b1b60e9d984d2bf747492ba2561eaaecc70ecc4
class Question(models.Model):
    question_text = models.CharField(max_length=200)
    pub_date = models.DateTimeField("date published")

<<<<<<< HEAD
    def __str__(self):
        return self.question_text

    @admin.display(
        boolean=True,
        ordering="pub_date",
        description="Published recently?",
    )
    def was_published_recently(self):
        now = timezone.now()
        return now - datetime.timedelta(days=1) <= self.pub_date <= now


class Choice(models.Model):
    question = models.ForeignKey(Question, on_delete=models.CASCADE)
    choice_text = models.CharField(max_length=200)
    votes = models.IntegerField(default=0)

    def __str__(self):
        return self.choice_text
=======
class Choice(models.Model):
    question = models.ForeignKey(Question, on_delete=models.CASCADE)
    choice_text = models.CharField(max_length=200)
    votes = models.IntegerField(default=0)
>>>>>>> 7b1b60e9d984d2bf747492ba2561eaaecc70ecc4
