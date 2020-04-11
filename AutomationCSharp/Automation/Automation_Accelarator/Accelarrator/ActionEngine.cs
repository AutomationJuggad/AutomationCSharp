using Automation.Automation_Accelarator.Reports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Automation_Accelarator.Accelarrator
{
    public class ActionEngine:TestEngine
    {
        /// <summary>
        /// Function Name :- FnOpenURL
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnOpenURL(string strURL,string strDescrription)
        {
            Boolean blnStatus = true;
            try
            {
                driver.Url = strURL;
                Reporter.Pass(strDescrription + " : Sussessfully Open the URL : " + strURL); 
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail("Unable to Open URL " + e.StackTrace); }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnNavigateURL
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnNavigateURL(string strURL, string strDescrription)
        {
            Boolean blnStatus = true;
            try
            {
                driver.Navigate().GoToUrl(strURL);
                Reporter.Pass(strDescrription + " : Sussessfully Navigate to the URL : " + strURL);
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail("Unable to Navigate to the URL : " + strURL +" \n Error Displayed :"  + e.StackTrace); }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnRefresh
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnRefresh()
        {
            Boolean blnStatus = true;
            try
            {
                driver.Navigate().Refresh();
                Reporter.Pass("Sussessfully Refresh the Browser : " + objConfig.Browser);
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail("Unable Refresh the Browser : " + objConfig.Browser + " \n Error Displayed :" + e.StackTrace); }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnBack
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnBack()
        {
            Boolean blnStatus = true;
            try
            {
                driver.Navigate().Back();
                Reporter.Pass("Sussessfully Back the Browser : " + objConfig.Browser);
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail("Unable Back the Browser : " + objConfig.Browser + " \n Error Displayed :" + e.StackTrace); }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnForward
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnForward()
        {
            Boolean blnStatus = true;
            try
            {
                driver.Navigate().Back();
                Reporter.Pass("Sussessfully Forward the Browser : " + objConfig.Browser);
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail("Unable Forward the Browser : " + objConfig.Browser + " \n Error Displayed :" + e.StackTrace); }
            return blnStatus;
        }


        /// <summary>
        /// Function Name :- FnGetTitle
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public string FnGetTitle()
        {
            string strTitle = "";
            try
            {
                strTitle = driver.Title;
                Reporter.Pass("Sussessfully get the Title : " + strTitle);
            }
            catch (Exception e) { Reporter.Fail("Unable to get the Title \n Error Displayed :" + e.StackTrace); }
            return strTitle;
        }

        /// <summary>
        /// Function Name :- FnGetPageSource
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public string FnGetPageSource()
        {
            string strPageSource = "";
            try
            {
                strPageSource = driver.PageSource;                
            }
            catch (Exception e) { Reporter.Fail("Unable to get the Title \n Error Displayed :" + e.StackTrace); }
            return strPageSource;
        }
        /// <summary>
        /// Function Name :- FnElementPresent
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnElementPresent(By elem)
        {
            Boolean blnStatus = true;
            try
            {
                IList<IWebElement> eleList = driver.FindElements(elem);
                if (eleList.Count == 0)
                    blnStatus = false;
            }
            catch (Exception e) { blnStatus = false;}
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnElementDisplayed
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnElementDisplayed(By elem,string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
               if(FnElementPresent(elem))
                    Reporter.Pass(strDescription + " : Element displayed successfully");
               else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnClick
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnClick(By elem, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        driver.FindElement(elem).Click();
                        Reporter.Pass(strDescription + " : Element Clicked successfully");
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element not Clicked"); }
                   
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnGetText
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public string FnGetText(By elem, string strDescription)
        {
            string strText = "";
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        strText = driver.FindElement(elem).Text;
                        Reporter.Pass(strDescription + " : Text Found : " + strText);
                    }
                    catch (Exception e) { strText = ""; Reporter.Fail(strDescription + " : Text not Found"); }
        
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) {}
            return strText;
        }

        /// <summary>
        /// Function Name :- FnGetAttribute
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public string FnGetAttribute(By elem,string strAttribute, string strDescription)
        {
            string strText = "";
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        strText = driver.FindElement(elem).GetAttribute(strAttribute);
                        Reporter.Pass(strDescription + " : Value By Attribute: " + strText);
                    }
                    catch (Exception e) { strText = ""; Reporter.Fail(strDescription + " : Value By Attribute not Found"); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { }
            return strText;
        }

        /// <summary>
        /// Function Name :- FnGetTagNAme
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public string FnGetTagNAme(By elem,string strDescription)
        {
            string strText = "";
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        strText = driver.FindElement(elem).TagName;
                        Reporter.Pass(strDescription + " : Tag Name : " + strText);
                    }
                    catch (Exception e) { strText = ""; Reporter.Fail(strDescription + " : Tag Name Not Found"); ; }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { }
            return strText;
        }

        /// <summary>
        /// Function Name :- FnSubmit
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnSubmit(By elem, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        driver.FindElement(elem).Click();
                        Reporter.Pass(strDescription + " : Element Submitted successfully");
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element not Submitted successfully"); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element not Submitted successfully"); }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnClear
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnClear(By elem, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        driver.FindElement(elem).Clear();
                        Reporter.Pass(strDescription + " : Element Clear successfully");
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element not Clear successfully"); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element not Clear successfully"); }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnIsEnable
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnIsEnable(By elem, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        if(driver.FindElement(elem).Enabled)
                            Reporter.Pass(strDescription + " : Element is Enable");
                        else
                            Reporter.Fail(strDescription + " : Element is not Enable");
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Enable"); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is Enable"); }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnIsSelected
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnIsSelected(By elem, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        if (driver.FindElement(elem).Selected)
                            Reporter.Pass(strDescription + " : Element is Selected");
                        else
                            Reporter.Fail(strDescription + " : Element is not Selected");
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Selected"); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is Selected"); }
            return blnStatus;
        }


        /// <summary>
        /// Function Name :- FnGetAllListElement
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public IList<IWebElement> FnGetAllListElement(By elem)
        {
            IList<IWebElement> eleList = new List<IWebElement>();
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            eleList = objSelect.Options;
                        }
                    }
                    catch (Exception e) {}
                }                
            }
            catch (Exception e) {}
            return eleList;
        }
        /// <summary>
        /// Function Name :- FnSelectByIndex
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnSelectByIndex(By elem,int index, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            try
                            {
                                objSelect.SelectByIndex(index);
                                Reporter.Pass(strDescription + " : Element is Selected By Index : " + index);
                            }
                            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Selected By Index : " + index); }
                        }
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Selected By Index : " + index); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Selected By Index : " + index); }
            return blnStatus;
        }
        /// <summary>
        /// Function Name :- FnSelectByValue
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnSelectByValue(By elem, string value, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            try
                            {
                                objSelect.SelectByValue(value);
                                Reporter.Pass(strDescription + " : Element is Selected By Value : " + value);
                            }
                            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Selected By Value : " + value); }
                        }
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Selected By Value : " + value); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Selected By Value : " + value); }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnSelectByVisibleText
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnSelectByVisibleText(By elem, string value, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            try
                            {
                                objSelect.SelectByText(value);
                                Reporter.Pass(strDescription + " : Element is Selected By Text : " + value);
                            }
                            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Selected By Text : " + value); }
                        }
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Selected By Text : " + value); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not Selected By Text : " + value); }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnGetAllOptioninText
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public List<String> FnGetAllOptioninText(By elem,string strDescription)
        {
            List<String> objData = new List<string>();
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            try
                            {
                                IList<IWebElement> eleList = objSelect.Options;
                                foreach (IWebElement element in eleList)
                                {
                                    objData.Add(element.Text);
                                }
                            }
                            catch (Exception e) { }
                        }
                    }
                    catch (Exception e) { Reporter.Fail(strDescription + " : Element is not Displaying Text in List"); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { Reporter.Fail(strDescription + " : Element is not Displaying Text in List"); }
            return objData;
        }
        /// <summary>
        /// Function Name :- FnGetSelectedOptioninList
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public String FnGetSelectedOptioninList(By elem, string strDescription)
        {
            string strData = "";
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            try
                            {
                                strData = objSelect.SelectedOption.Text;
                            }
                            catch (Exception e) { }
                        }
                    }
                    catch (Exception e) { Reporter.Fail(strDescription + " : Element is not Displaying Selected Text in List"); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { Reporter.Fail(strDescription + " : Element is not Displaying Selected ext in List"); }
            return strData;
        }

        /// <summary>
        /// Function Name :- FnGetItemCountInList
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Int64 FnGetItemCountInList(By elem, string strDescription)
        {
            Int64 intCount = 0;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        intCount = objSelect.Options.Count;
                    }
                    catch (Exception e) { Reporter.Fail(strDescription + " : Element is not Displaying Selected Text in List"); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { Reporter.Fail(strDescription + " : Element is not Displaying Selected ext in List"); }
            return intCount;
        }

        /// <summary>
        /// Function Name :- FnIMultipleSelect
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnIMultipleSelect(By elem,string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            try
                            {
                                blnStatus = objSelect.IsMultiple;
                            }
                            catch (Exception e) { blnStatus = false;}
                        }
                    }
                    catch (Exception e) { blnStatus = false;}
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false;}
            return blnStatus;
        }
        /// <summary>
        /// Function Name :- FnDeSelectByIndex
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnDeSelectByIndex(By elem, int index, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            try
                            {
                                objSelect.DeselectByIndex(index);
                                Reporter.Pass(strDescription + " : Element is De-Selected By Index : " + index);
                            }
                            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not De-Selected By Index : " + index); }
                        }
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not De-Selected By Index : " + index); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not De-Selected By Index : " + index); }
            return blnStatus;
        }
        /// <summary>
        /// Function Name :- FnDeSelectByValue
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnDeSelectByValue(By elem, string value, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            try
                            {
                                objSelect.DeselectByValue(value);
                                Reporter.Pass(strDescription + " : Element is De-Selected By Value : " + value);
                            }
                            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not De-Selected By Value : " + value); }
                        }
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not De-Selected By Value : " + value); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not De-Selected By Value : " + value); }
            return blnStatus;
        }

        /// <summary>
        /// Function Name :- FnDeSelectByVisibleText
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public Boolean FnDeSelectByVisibleText(By elem, string value, string strDescription)
        {
            Boolean blnStatus = true;
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            try
                            {
                                objSelect.DeselectByText(value);
                                Reporter.Pass(strDescription + " : Element is De-Selected By Text : " + value);
                            }
                            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not De-Selected By Text : " + value); }
                        }
                    }
                    catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not De-Selected By Text : " + value); }
                }
                else
                    Reporter.Fail(strDescription + " : Element not displayed.");
            }
            catch (Exception e) { blnStatus = false; Reporter.Fail(strDescription + " : Element is not De-Selected By Text : " + value); }
            return blnStatus;
        }
        /// <summary>
        /// Function Name :- FnGetAllSelectedOptionInList
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public IList<IWebElement> FnGetAllSelectedOptionInList(By elem)
        {
            IList<IWebElement> eleList = new List<IWebElement>();
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        SelectElement objSelect = new SelectElement(driver.FindElement(elem));
                        if (objSelect.Options.Count > 0)
                        {
                            eleList = objSelect.AllSelectedOptions;
                        }
                    }
                    catch (Exception e) { }
                }
            }
            catch (Exception e) { }
            return eleList;
        }

        /// <summary>
        /// Function Name :- FnGetAllElementByTagName
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public IList<IWebElement> FnGetAllElementByTagName(By elem,string strTagName)
        {
            IList<IWebElement> eleList = new List<IWebElement>();
            try
            {
                if (FnElementPresent(elem))
                {
                    try
                    {
                        eleList=driver.FindElement(elem).FindElements(By.TagName(strTagName));
                    }
                    catch (Exception e) { }
                }
            }
            catch (Exception e) { }
            return eleList;
        }
    }
}
