Data analysis of 單身分析師
===

2017 / 08 / 26

Created by <font color="#006699">**Ian Hsu**</font> in MSP Hackathon

---

## Data from Kaggle
Resource: [Speed Dating Experient](https://www.kaggle.com/annavictoria/speed-dating-experiment)

Original Data:
*    iid
unique subject number, group(wave id gender)
*    id
subject number within wave
*    gender
Female=0, Male=1
*    idg
subject number within gender, group(id gender)
*    condtn:
	1=limited choice, 2=extensive choice
*    wave:
Num, Male, Female, **Note**
1, 10, 10
2, 16, 19
3, 10, 9
4, 18, 18
5, 10, 10, **undergrads**
6, 5, 5, **1-10 scale**
7, 16, 16, **1-10 scale**
8, 10, 10, **1-10 scale**
9, 20, 20, **1-10 scale**
10, 9, 9
11, 21, 21
12, 14, 15, **Budget: only allowed to yes yes to 50% of the people that met**
13, 9, 10, **Different M.C.**
14, 18, 20, **Different M.C.**
15, 19, 18
16, 8, 6
17, 14, 10
18, 6, 6, **brought a magazine**
19, 15, 16, **brought a book**
20, 8, 6, **brought a book**
21, 22, 22, **brought a magazine**
*    round
number of people that met in wave
*    position
station number where met partner 
*    positin1
station number where started 
*    order
the number of date that night when met partner
*    partner
partner’s id number the night of event
*    pid
partner’s iid number
*    match
1=yes, 0=no
*    int_corr
correlation between participant’s and partner’s ratings of interests in Time 1
*    samerace
participant and the partner were the same race. 1= yes, 0=no
*    age_o
age of partner
*    race_o
race of partner
*    pf_o_att, pf_o_sin, pf_o_int, pf_o_fun, pf_o_amb, pf_o_sha
partner’s stated preference at Time 1 (attr1_1) for all 6 attributes
*    dec_o
decision of partner the night of event
*    attr_o, sinc_o, intel_o, fun_o, amb_o, shar_o
rating by partner the night of the event, for all 6 attributes
*    like_o
rating by partner the night of the event, for how much did your partner like you? (1=don't like at all, 10=like a lot)
*    prob_o
rating by partner the night of the event, for how probable did your partner think you will say 'yes' to him/her? (1=not probable, 10=extremely probable)
*    met_o
Have your partner met you before? (1=yes, 2=no)

==signup/Time1 [Survey filled out by students that are registering for the event.]==
*    age
*    field
field of study
*    field_cd
field coded: 
1=Law
2=Math
3=Social Science, Psychologist 
4=Medical Science, Pharmaceuticals, and Bio Tech 
5=Engineering
6=English/Creative Writing/ Journalism 
7=History/Religion/Philosophy 
8=Business/Econ/Finance 
9=Education, Academia 
10=Biological Sciences/Chemistry/Physics
11=Social Work 
12=Undergrad/undecided 
13=Political Science/International Affairs 
14=Film
15=Fine Arts/Arts Administration
16=Languages
17=Architecture
18=Other
*    undergrd
school attended for undergraduate degree
*    mn_sat
Median SAT score for the undergraduate institution where attended. Taken from Barron’s 25th Edition college profile book. Proxy for intelligence.
*    tuition
Tuition listed for each response to undergrad in Barron’s 25th Edition college profile book.
*    race
Black/African American=1
European/Caucasian-American=2
Latino/Hispanic American=3
Asian/Pacific Islander/Asian-American=4
Native American=5
Other=6
*    imprace
How important is it to you (on a scale of 1-10) that a person you date be of the same racial/ethnic background?
*    imprelig
How important is it to you (on a scale of 1-10) that a person you date be of the same religious background?
*    from
Where are you from originally (before coming to Columbia)? 
*    zipcode
What was the zip code of the area where you grew up? 
*    income
Median household income based on zipcode using the Census Bureau website:
http://venus.census.gov/cdrom/lookup/CMD=LIST/DB=C90STF3B/LEV=ZIP 
When there is no income it means that they are either from abroad or did not enter their zip code.
*    goal
What is your primary goal in participating in this event: 
Seemed like a fun night out=1
To meet new people=2
To get a date=3
Looking for a serious relationship=4
To say I did it=5
Other=6
*    date
In general, how frequently do you go on dates:
Several times a week=1
Twice a week=2
Once a week=3
Twice a month=4
Once a month=5
Several times a year=6
Almost never=7
*    go_out
How often do you go out (not necessarily on dates):
Several times a week=1
Twice a week=2
Once a week=3
Twice a month=4
Once a month=5
Several times a year=6
Almost never=7
*    career
What is your intended career
*    career_c
career coded:
1=Lawyer 
2=Academic/Research 
3=Psychologist 
4=Doctor/Medicine 
5=Engineer 
6=Creative Arts/Entertainment 
7=Banking/Consulting/Finance/Marketing/Business/CEO/Entrepreneur/Admin 
8=Real Estate 
9=International/Humanitarian Affairs 
10=Undecided 
11=Social Work
12=Speech Pathology
13=Politics
14=Pro sports/Athletics
15=Other
16=Journalism
17=Architecture
*    How interested are you in the following activities, on a scale of 1-10?
        *    sports
        Playing sports/athletics
        *    tvsports
        Watching sports
        *    exercise
        Body building/exercising
        *    dining
        Dining out
        *    museums
        Museums/galleries
        *    art
        Art
        *    hiking
        Hiking/camping
        *    gaming
        Gaming
        *    clubbing
        Dancing/clubbing
        *    reading
        Reading
        *    tv
        Watching TV
        *    theater
        Theater
        *    movies
        Movies
        *    concerts
        Going to concerts
        *    music
        Music
        *    shopping
        Shopping
        *    yoga
        Yoga/meditation
*    exphappy
Overall, on a scale of 1-10, how happy do you expect to be with the people you meet during the speed-dating event?
*    expnum
Out of the 20 people you will meet, how many do you expect will be interested in dating you?
*    We want to know what you look for in the opposite sex. Please rate the importance of the following attributes in a potential date.
<font color="red">Waves 6-9: 1-10 scale (1=not at all important, 10=extremely important)
Waves 1-5, 10-21: Give more points to important attributes and fewer points to not important attributes. Total points must equal 100.</font>
        *    attr1_1 
        Attractive
        *    sinc1_1
        Sincere
        *    intel1_1
        Intelligent
        *    fun1_1
        Fun
        *    amb1_1
        Ambitious
        *    shar1_1
        Has shared interests/hobbies
*    Now we want to know what you think MOST of your fellow men/women look for in the opposite sex. Please rate the importance of the following attributes.
<font color="red">Waves 6-9: 1-10 scale (1=not at all important, 10=extremely important)
Waves 1-5, 10-21: Give more points to important attributes and fewer points to not important attributes. Total points must equal 100.</font>
        *    attr4_1
        Attractive
        *    sinc4_1
        Sincere
        *    intel4_1
        Intelligent
        *    fun4_1
        Fun
        *    amb4_1
        Ambitious
        *    shar4_1
        Shared Interests/Hobbies
*    What do you think the opposite sex looks for in a date? Please rate the importance of the following attributes.
<font color="red">Waves 6-9: 1-10 scale (1=not at all important, 10=extremely important)
Waves 1-5, 10-21: Give more points to important attributes and fewer points to not important attributes. Total points must equal 100.</font>
        *    attr2_1
        Attractive
        *    sinc2_1
        Sincere
        *    intel2_1
        Intelligent
        *    fun2_1
        Fun
        *    amb2_1
        Ambitious
        *    shar2_1
        Shared Interests/Hobbies
*    How do you think you measure up? Please rate your opinion of your own attributes, on a scale of 1-10.
        *    attr3_1
        Attractive
        *    sinc3_1
        Sincere
        *    intel3_1
        Intelligent
        *    fun3_1
        Fun
        *    amb3_1
        Ambitious
*    And finally, how do you think others perceive you? Please rate yourself how you think others would rate you on each of the following attributes, on a scale of 1-10 (1=awful, 10=great).
        *    attr5_1
        Attractive
        *    sinc5_1
        Sincere
        *    intel5_1
        Intelligent
        *    fun5_1
        Fun
        *    amb5_1
        Ambitious

==Scorecard [Filled out by subjects after each "date" during the event.]==
*    Indicate whether or not you would like to see him or her again. (1=yes, 0=no)
        *    dec
*    For each person you meet, rate their attributes on a scale of 1-10 (1=awful, 10=great). If you haven’t formed an opinion based on your conversation, fill in N/A.
        *    attr
        Attractive
        *    sinc
        Sincere
        *    intel
        Intelligent
        *    fun
        Fun
        *    amb
        Ambitious
        *    shar
        Shared Interests/Hobbies				
		*    like
		Overall, how much do you like this person (1=don't like at all, 10=like a lot)
        *    prob
        How probable do you think it is that this person will say 'yes' for you? (1=not probable, 10=extremely probable)
        *    met
        Have you met this person before? (1=yes, 2=no)
*    match_es
How many matches do you estimate you will get (a match occurs when you and your partner both check “Yes” next to decision)?

==Half way through meeting all potential dates during the night of the event on their scorecard==

*    We want to know what you look for in the opposite sex. Please rate the importance of the following attributes in a potential date on a scale of 1-10 (1=not at all important, 10=extremely important).
        *    attr1_s
        Attractive
        *    sinc1_s
        Sincere
        *    intel1_s
        Intelligent
        *    fun1_s
        Fun
        *    amb1_s
        Ambitious
        *    shar1_s
        Shared Interests/Hobbies
*    Please rate your opinion of your own attributes, on a scale of 1-10 (1=awful, 10=great).
        *    attr3_s
        Attractive
        *    sinc3_s
        Sincere
        *    intel3_s
        Intelligent
        *    fun3_s
        Fun
        *    amb3_s
        Ambitious
        *    shar3_s
        Shared Interests/Hobbies

==followup/Time2 [Survey is filled out the day after participating in the event. Subjects must have submitted this in order to be sent their matches.]==
*    satis_2
Overall, how satisfied were you with the people you met? (1=not at all satisfied, 10=extremely satisfied)
*    length
Four minutes is:
Too little=1
Too much=2
Just Right=3
*    numdat_2
The number of Speed "Dates" you had was:	
Too few=1
Too many=2
Just right=3
*    Now, think back to your yes/no decisions during the Speed Dating event.  Try to distribute the 100 points among these six attributes in the way that best reflects the actual importance of these attributes in your decisions.
        *    attr7_2
        Attractive
        *    sinc7_2
        Sincere
        *    intel7_2
        Intelligent
        *    fun7_2
        Fun
        *    amb7_2
        Ambitious
        *    shar7_2
        Shared Interests/Hobbies
*    We want to know what you look for in the opposite sex. Please rate the importance of the following attributes.
<font color="red">Waves 6-9: 1-10 scale (1=not at all important, 10=extremely important)
Waves 1-5, 10-21: Give more points to important attributes and fewer points to not important attributes. Total points must equal 100.</font>
        *    attr1_2
        Attractive
        *    sinc1_2
        Sincere
        *    intel1_2
        Intelligent
        *    fun1_2
        Fun
        *    amb1_2
        Ambitious
        *    shar1_2
        Shared Interests/Hobbies
*    What do you think MOST of your fellow men/women look for in the opposite sex? You have 100 points to distribute among the following attributes.
        *    attr4_2
        Attractive
        *    sinc4_2
        Sincere
        *    intel4_2
        Intelligent
        *    fun4_2
        Fun
        *    amb4_2
        Ambitious
        *    shar4_2
        Shared Interests/Hobbies
*    What do you think the opposite sex looks for in a date? Please distribute 100 points among the following attributes.
        *    attr2_2
        Attractive
        *    sinc2_2
        Sincere
        *    intel2_2
        Intelligent
        *    fun2_2
        Fun
        *    amb2_2
        Ambitious
        *    shar2_2
        Shared Interests/Hobbies
*    How do you think you measure up? Please rate your opinion of your own attributes, on a scale of 1-10 (1= awful, 10=great).
        *    attr3_2
        Attractive
        *    sinc3_2
        Sincere
        *    intel3_2
        Intelligent
        *    fun3_2
        Fun
        *    amb3_2
        Ambitious
*    How do you think others perceive you? Please rate yourself how you think others would rate you on each of the following attributes, on a scale of 1-10 (1=awful, 10=great).
        *    attr5_2
        Attractive
        *    sinc5_2
        Sincere
        *    intel5_2
        Intelligent
        *    fun5_2
        Fun
        *    amb5_2
        Ambitious
	
==followup2/Time3 [Subjects filled out 3-4 weeks after they had been sent their matches]==

*    Since hurrydating, in the matches that you received:
        *    you_call
        How many have you contacted to set up a date?
        *    them_cal
        How many have contacted you?
*    date_3
Have you been on a date with any of your matches? (1=Yes, 2=No)
*    If you have been on at least one date, please answer the following:
        *    numdat_3
        How many of your matches have you been on a date with so far?
        *    num_in_3
        If yes, how many?
*    What do you look for in the opposite sex? Please rate the importance of the following attributes.
<font color="red">Waves 6-9: 1-10 scale (1=not at all important, 10=extremely important)
Waves 1-5, 10-21: Give more points to important attributes and fewer points to not important attributes. Total points must equal 100.</font>
        *    attr1_3
        Attractive
        *    sinc1_3
        Sincere
        *    intel1_3
        Intelligent
        *    fun1_3
        Fun
        *    amb1_3
        Ambitious
        *    shar1_3
        Shared Interests/Hobbies
*    Now, think back to your yes/no decisions during the night of the Speed Dating event.  Try to distribute the 100 points among these six attributes in the way that best reflects the actual importance of these attributes in your decisions.
        *    attr7_3
        Attractive
        *    sinc7_3
        Sincere
        *    intel7_3
        Intelligent
        *    fun7_3
        Fun
        *    amb7_3
        Ambitious
        *    shar7_3
        Shared Interests/Hobbies
*    We want to know what you think MOST of your fellow men/women look for in the opposite sex. Please rate the importance of the following attributes on a scale of 1-10 (1=not at all important, 10=extremely important).
        *    attr4_3
        Attractive
        *    sinc4_3
        Sincere
        *    intel4_3
        Intelligent
        *    fun4_3
        Fun
        *    amb4_3
        Ambitious
        *    shar4_3
        Shared Interests/Hobbies
*    What do you think the opposite sex looks for in a date?  Please rate the importance of the following attributes on a scale of 1-10 (1=not at all important, 10=extremely important).
        *    attr2_3
        Attractive
        *    sinc2_3
        Sincere
        *    intel2_3
        Intelligent
        *    fun2_3
        Fun
        *    amb2_3
        Ambitious
        *    shar2_3
        Shared Interests/Hobbies
*    Please rate your opinion of your own attributes, on a scale of 1-10 (1= awful and 10=great).
        *    attr3_3
        Attractive
        *    sinc3_3
        Sincere
        *    intel3_3
        Intelligent
        *    fun3_3
        Fun
        *    amb3_3
        Ambitious
*    How do you think others perceive you? Please rate yourself how you think others would rate you on each of the following attributes, on a scale of 1-10 (1=awful, 10=great).
        *    attr5_3
        Attractive
        *    sinc5_3
        Sincere
        *    intel5_3
        Intelligent
        *    fun5_3
        Fun
        *    amb5_3
        Ambitious

---

## Data Analysis

### Variables used
#### Features
*    **gender**
Female=0, Male=1
*    age
*    **go_out**
How often do you go out (not necessarily on dates):
Several times a week=1
Twice a week=2
Once a week=3
Twice a month=4
Once a month=5
Several times a year=6
Almost never=7
*    How interested are you in the following activities, on a scale of 1-10?
        *    **sports**
        Playing sports/athletics
        *    **tvsports**
        Watching sports
        *    exercise
        Body building/exercising
        *    dining
        Dining out
        *    museums
        Museums/galleries
        *    art
        Art
        *    **hiking**
        Hiking/camping
        *    **gaming**
        Gaming
        *    clubbing
        Dancing/clubbing
        *    reading
        Reading
        *    **tv**
        Watching TV
        *    theater
        Theater
        *    movies
        Movies
        *    concerts
        Going to concerts
        *    music
        Music
        *    **shopping**
        Shopping
        *    **yoga**
        Yoga/meditation
*    We want to know what you look for in the opposite sex. Please rate the importance of the following attributes in a potential date.
<font color="red">Waves 6-9: 1-10 scale (1=not at all important, 10=extremely important)
Waves 1-5, 10-21: Give more points to important attributes and fewer points to not important attributes. Total points must equal 100.</font>
        *    attr1_1 
        Attractive
        *    sinc1_1
        Sincere
        *    intel1_1
        Intelligent
        *    fun1_1
        Fun
        *    amb1_1
        Ambitious
        *    shar1_1
        Has shared interests/hobbies

#### Response
*    **dec_o** <font color="#006699">**惹人愛的指數**</font>
decision of partner the night of event
