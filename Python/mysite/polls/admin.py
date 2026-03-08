from django.contrib import admin
<<<<<<< HEAD
from .models import Question, Choice


class ChoiceInline(admin.TabularInline):
    model = Choice
    extra = 3


class QuestionAdmin(admin.ModelAdmin):
    fieldsets = [
        (None, {"fields": ["question_text"]}),
        ("Date information", {"fields": ["pub_date"], "classes": ["collapse"]}),
    ]

    inlines = [ChoiceInline]

    list_display = ["question_text", "pub_date", "was_published_recently"]
    list_filter = ["pub_date"]
    search_fields = ["question_text"]

admin.site.register(Question, QuestionAdmin)
admin.site.register(Choice)
=======

from django.contrib import admin
from .models import Question

admin.site.register(Question)
>>>>>>> 7b1b60e9d984d2bf747492ba2561eaaecc70ecc4
