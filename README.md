# Confoguration for Autohause website to use Solt search provider 


## Installation of Autohaus

Follow instructions from https://github.com/Sitecore/autohaus

## Installation of Solr

Use Bitnami (http://bitnami.com/stack/solr) or any other Solr package.

See chapter 3 of Sitecore 7 Search Scaling Gude (http://sdn.sitecore.net/upload/sitecore7/70/sitecore_search_scaling%20guide_sc7-a4.pdf)

Solr core name should be autohaus.

Use config files from solr folder.

"3.2.3 Generating an XML Schema for Solr" and "3.2.4 Enabling Solr Term Support "can be skipped - schema.xml and solrconfig.xml contains these changes. 

## Sitecore Configuration

Rename *.config files as described in 3.4.1

Copy files from sitecore/website folder to your site web folder.

Rebuild indexes as described in 3.5



