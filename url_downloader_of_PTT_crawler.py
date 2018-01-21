import unittest
import codecs, json, os
import time
import re,os,sys

# Put your JSON file path of PTT_crawler in Beauty here
FilePath = "your JSON file path"

def get_contents(JsonPath):
    with open(JsonPath, 'r',encoding = 'utf-8') as f:
        s = f.read()
        data = json.loads(s)
    contents = []
    titles = []
    article_ids = []
    for article in data['articles']:
        contents.append(article['content'])
        titles.append(article['article_title'])
        article_ids.append(article['article_id'])
    return(contents,titles,article_ids)

contents,titles,article_ids = get_contents(FilePath)
#contents

index = 0
Beauty_images_urls = []
for content in contents:
    if titles[index].startswith('[正妹]'):
        Beauty_images_urls.append(re.findall('http[s]?://(?:[a-zA-Z]|[0-9]|[$-_@.&+]|[!*\(\),]|(?:%[0-9a-fA-F][0-9a-fA-F]))+', content))
    index = index + 1
#Beauty_images_urls

# Flatten the list of Beauty_images_urls
Beauty_images_urls_list = []
for x in Beauty_images_urls:
    for y in x:
        if y.startswith(('https://i.imgur','http://i.imgur','https://imgur','http://imgur')) and y.endswith('.jpg'):
            Beauty_images_urls_list.append(y)
#Beauty_images_urls_list

# Output urls into Beauty_images_urls.csv
OutputFile = open('Beauty_images_urls.csv', 'a')
for url in Beauty_images_urls_list:
    OutputFile.write("%s\n" % url)
OutputFile.close()
