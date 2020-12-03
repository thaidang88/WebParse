#Run on https://colab.research.google.com

import requests
from bs4 import BeautifulSoup

URL = 'https://www.kitco.com'
page = requests.get(URL)

soup = BeautifulSoup(page.content, 'html.parser')

# results= soup.find('table', id="QBS_2_inner")
results= soup.find( id="lgq-bid")
# results=soup.find('title')
print('Bid :'+results.text)
results= soup.find( id="lgq-ask")
# results=soup.find('title')
print('Ask :'+results.text)


# Parse all job from 1 page in itviec

import requests
from bs4 import BeautifulSoup

URL = 'https://itviec.com/it-jobs/ho-chi-minh-hcm'
page = requests.get(URL)

soup = BeautifulSoup(page.content, 'html.parser')
# results = soup.find(class='job_content')
job_elems = soup.find_all( class_='job_content')

for job_elem in job_elems:
    # Each job_elem is a new BeautifulSoup object.
    # You can use the same methods on it as you did before.
    title_elem = job_elem.find('h2', class_='title')
    salary_elem = job_elem.find('div', class_='salary')
    location_elem = job_elem.find('div', class_='address')
    print(title_elem.text.strip())
    print(salary_elem.text.strip())
    print(location_elem.text.strip())
    company_elem = job_elem.find_all('img')
    for a in company_elem:
      print(a['alt'])
    print()
    
#Parse bitcoin price

import requests
from bs4 import BeautifulSoup

URL = 'https://www.coindesk.com/price/bitcoin'
page = requests.get(URL)

soup = BeautifulSoup(page.content, 'html.parser')
element = soup.find('div',class_='price-large')
print("Price: "+element.text.strip())
element = soup.find('div',class_='percent-change-medium')
print("Pct: "+element.text.strip())
elements=soup.find_all(class_='percent-change-medium')
for a in elements:
  print(a.text.strip())

#Detect vnindex. Currently not success???
from urllib.request import Request, urlopen
from bs4 import BeautifulSoup as soup

URL = 'https://cafef.vn'

req = Request(URL , headers={'User-Agent': 'Mozilla/5.0'})

webpage = urlopen(req).read()
page_soup = soup(webpage, "html.parser")

#soup = BeautifulSoup(page.content, 'html.parser')
#print(soup)
element = page_soup.find_all(class_='bieudo_header')
for a in element:
  vnindex = a.find('b',class_='idx_1')
  print(vnindex)
vnindex=page_soup.find('b',class_='idx_1')
print(vnindex)

#Detect fool.ca
from urllib.request import Request, urlopen
from bs4 import BeautifulSoup as soup
url = 'https://www.fool.ca/recent-headlines/'
req = Request(url , headers={'User-Agent': 'Mozilla/5.0'})

webpage = urlopen(req).read()
page_soup = soup(webpage, "html.parser")
title = page_soup.find("title")
print(title)
containers = page_soup.findAll("p","promo")
for container in containers:
    print(container)
    
    
#Get Vnindex
from urllib.request import Request, urlopen
from bs4 import BeautifulSoup as soup
URL = 'https://www.bloomberg.com/quote/VNINDEX:IND'
req = Request(URL , headers={'User-Agent': 'Mozilla/5.0'})

webpage = urlopen(req).read()
page_soup = soup(webpage, "html.parser")
vnindex= page_soup.find_all(class_='priceText__1853e8a5')
print(vnindex)

#Get Weather
from urllib.request import Request, urlopen
from bs4 import BeautifulSoup as soup
url = 'https://www.accuweather.com/vi/vn/ho-chi-minh-city/353981/hourly-weather-forecast/353981'
req = Request(url , headers={'User-Agent': 'Mozilla/5.0'})

webpage = urlopen(req).read()
page_soup = soup(webpage, "html.parser")
title = page_soup.find("title")
print(title)
containers = page_soup.findAll('div',class_='accordion-item-header-container')
for container in containers:
    date=container.find('h2',class_='date')
    temperature=container.find('div',class_='temp metric')
    real_feel=container.find('span',class_='real-feel')
    phase=container.find('span',class_='phrase')
    print(date.text.strip())
    print(temperature.text.strip())
    print(real_feel)
    print(phase)

#Get Covid 19
from urllib.request import Request, urlopen
from bs4 import BeautifulSoup as soup
url = 'https://www.worldometers.info/coronavirus/?'
req = Request(url , headers={'User-Agent': 'Mozilla/5.0'})

webpage = urlopen(req).read()
page_soup = soup(webpage, "html.parser")
title = page_soup.find("title")
print(title)
containers = page_soup.findAll('div',class_='maincounter-number')
for container in containers:
    print(container.text.strip())
    
#Get href and images info
from urllib.request import Request, urlopen
from bs4 import BeautifulSoup as soup
url = 'https://vnexpress.net'
req = Request(url , headers={'User-Agent': 'Mozilla/5.0'})

webpage = urlopen(req).read()
page_soup = soup(webpage, "html.parser")
title = page_soup.find("title")
print(title)
for a in page_soup.find_all('a', href=True):
    print(a.get('title'))
    print(a.get('href'))
images = page_soup.find_all('img')
for image in images:
    #print image source
    print(image['src'])
    #print alternate text
    print(image['alt'])    

#Parse dictionary
from urllib.request import Request, urlopen
from bs4 import BeautifulSoup as soup
url = 'https://dictionary.cambridge.org/dictionary/english-japanese/go'
req = Request(url , headers={'User-Agent': 'Mozilla/5.0'})

webpage = urlopen(req).read()
page_soup = soup(webpage, "html.parser")
title = page_soup.find("title")
print(title)
meaning = page_soup.find_all('span',class_='trans dtrans dtrans-se')
for mean in meaning:
  print(mean.text.strip())

#Get images and href
from urllib.request import Request, urlopen
from bs4 import BeautifulSoup as soup
url = 'https://dantri.com.vn'
req = Request(url , headers={'User-Agent': 'Mozilla/5.0'})

webpage = urlopen(req).read()
page_soup = soup(webpage, "html.parser")
title = page_soup.find("title")
print(title)
for a in page_soup.find_all('a', href=True):
    print(a.get('title'))
    print(a.get('href'))
    images=a.find_all('img')
    for image in images:
      print(image['src'])
      # print(image['alt'])
# images = page_soup.find_all('img')
# for image in images:
#     #print image source
#     print(image['src'])
#     #print alternate text
#     print(image['alt'])
